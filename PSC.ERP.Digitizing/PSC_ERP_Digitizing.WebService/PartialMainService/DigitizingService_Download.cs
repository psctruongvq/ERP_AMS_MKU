using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
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
        public byte[] DownloadFile(String publicKey, String token, string filePath, string pdfPassword = null)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                return DownloadFile_Helper(filePath, pdfPassword);
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
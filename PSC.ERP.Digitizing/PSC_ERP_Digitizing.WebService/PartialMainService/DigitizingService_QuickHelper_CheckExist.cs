using iTextSharp.text.pdf;
using PSC_ERP_Digitizing.WebService.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;


namespace PSC_ERP_Digitizing.WebService
{
    public partial class DigitizingService
    {
        [WebMethod]
        public Boolean QuickHelper_CheckExistSourceFile_ByFileName(String publicKey, String token, String fileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {

                
                String filePath = Path.Combine(_sourceDirectory, fileNameWithExtension);
                return File.Exists(filePath);
               
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
        public Boolean QuickHelper_CheckExistConvertedFile_ByFileName(String publicKey, String token, String fileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {

                
                String filePath = Path.Combine(_convertedDirectory, fileNameWithExtension);
                return File.Exists(filePath);
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
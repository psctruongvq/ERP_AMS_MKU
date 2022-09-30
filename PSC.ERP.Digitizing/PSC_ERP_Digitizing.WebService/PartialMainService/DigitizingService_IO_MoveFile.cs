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
        public void IO_MoveFile(String publicKey, String token, String sourceFilePath, String destFilePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    File.Move(sourceFilePath, destFilePath);
                }
                catch (Exception ex)
                {
                    //Throw the exception    
                    SoapException se = new SoapException("Move file error",
                      SoapException.ClientFaultCode,
                      Context.Request.Url.AbsoluteUri,
                      ex);
                    throw se;
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

       


        [WebMethod]
        public Boolean IO_TryMoveFile(String publicKey, String token, String sourceFilePath, String destFilePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    File.Move(sourceFilePath, destFilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
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
using iTextSharp.text.pdf;
using PSC_ERP_Digitizing.WebService.Util;
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
        public void IO_DeleteFile(String publicKey, String token, string filePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        // A.
                        // Try to delete the file.
                        File.Delete(filePath);

                    }
                    catch (IOException ex)
                    {
                        //Throw the exception    
                        SoapException se = new SoapException("DeleteFile error",
                          SoapException.ClientFaultCode,
                          Context.Request.Url.AbsoluteUri,
                          ex);
                        throw se;
                    }
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
        public Boolean IO_TryDeleteFile(String publicKey, String token, string filePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                return IOUtil.TryDeleteFile(filePath);
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

        


        // //////////////////////////////////////////////////

        [WebMethod]
        public void IO_DeleteDir(String publicKey, String token, string dirPath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                if (Directory.Exists(dirPath))
                {
                    try
                    {
                        // A.
                        // Try to delete
                        Directory.Delete(dirPath);

                    }
                    catch (IOException ex)
                    {
                        //Throw the exception    
                        SoapException se = new SoapException("Delete dir error",
                          SoapException.ClientFaultCode,
                          Context.Request.Url.AbsoluteUri,
                          ex);
                        throw se;
                    }
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
        public Boolean IO_TryDeleteDir(String publicKey, String token, string dirPath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                return IOUtil.TryDeleteDir(dirPath);
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
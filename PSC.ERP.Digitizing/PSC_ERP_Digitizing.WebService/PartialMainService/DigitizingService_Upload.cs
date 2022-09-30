using iTextSharp.text.pdf;
using PSC_ERP_Digitizing.WebService.Util;
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
        public void UploadPdfFile(String publicKey, String token, byte[] f, string destFileName, string destDirPath, string key)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                UploadPdfFile_Helper(f, destFileName, destDirPath, key);

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

        private void UploadPdfFile_Helper(byte[] f, string destFileName, string destDirPath, string key)
        {
            try
            {
                PdfReader pReader = new PdfReader(f);
                PdfEncryptor.Encrypt(pReader, new FileStream(destDirPath + destFileName, FileMode.Create), PdfWriter.STRENGTH128BITS, key, key, PdfWriter.AllowScreenReaders);

                IOUtil.SetAllowFullAccessFileForEveryone(Path.Combine(destDirPath, destFileName));
            }
            catch (Exception ex)
            {
                //Throw the exception    
                SoapException se = new SoapException("UploadPdfFile Error",
                  SoapException.ClientFaultCode,
                  Context.Request.Url.AbsoluteUri,
                  ex);
                throw se;
                //return ex.Message;
            }
        }











        [WebMethod]
        public void UploadFileLargeSize(String publicKey, String token, string destFilePath, byte[] buffer, long offset)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    Helper.Digitizing_UploadFileLargeSize(destFilePath: destFilePath, buffer: buffer, offset: offset);

                }
                catch (Exception ex)
                {
                    //Throw the exception    
                    SoapException se = new SoapException("Digitizing_UploadFileLargeSize error",
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

        

    }
}